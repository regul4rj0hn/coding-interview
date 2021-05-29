# Explain
You don't have to remember any YAML file definition by heart, you can just use the explain command to check for their format. Here are some examples:
- `kubectl explain pods`: top-level elements for a pod definition explained
- `kubectl explain pods --recursive`: full pod definition file with all of its objects in yaml format
- `kubectl explain pods.spec.containers --recursive`: containers section definition with all of its objects in yaml format
- `kubectl explain pods --recursive | grep -A5 template`: gets the 5 lines after the first word "template"
- `kubectl explain pods | less`: you might need scrolling

# Filtering
If you need to count or find elements on a cluster, label filtering might come in handy. Here are some examples:
- `kubectl get pods --selector env=prod`: gets pods with the prod environment label
- `kubectl get all --selector env=prod,tier=api`: gets all elements (pods, deployments, services, etc) with the prod environment label in the api tier
- `kubectl get pods -l env=dev -l bu=finance`: gets pods from the dev environment and finance business unit
- `kubectl get all --no-headers`: gets all cluster elements and outputs the result without table headers
- `kubectl get pods --no-headers | wc -l`: gets all the pods without headers and then counts the number of lines in the output, i.e. number of pods 

# Output Formatting
The default output format for all kubectl commands is the human-readable plain-text format, but the `-o` flag allows us to output the details in several different formats:
```kubectl [command] [TYPE] [NAME] -o <output_format>```
Here are some of the commonly used formats:
- `-o json`: Output a JSON formatted API object.
- `-o name`: Print only the resource name and nothing else.
- `-o wide`: Output in the plain-text format with any additional information.
- `-o yaml`: Output a YAML formatted API object.

This fact combined with the `--dry-run` option can be helpful to quickly create a definition file. E.g. output with YAML format:
```bash
$ kubectl create namespace test-123 --dry-run -o yaml
apiVersion: v1
kind: Namespace
metadata:
  creationTimestamp: null
  name: test-123
spec: {}
status: {}
```

# Imperative Commands
While you would mostly be working mostly the declarative way - using definition files, imperative commands can help in getting one time tasks done quickly, as well as generate a definition template easily. This helps save a considerable amount of time during certifications. Before we begin, familiarize with the two options that can come in handy while working with the below commands:
- `--dry-run`: By default as soon as the command is run, the resource will be created. If you simply want to test your command, use the `--dry-run=client` option. This will not create the resource, instead, tell you whether the resource can be created and if your command is right.
- `-o yaml`: This will output the resource definition in YAML format on the screen.
Use the above two in combination to generate a resource definition file quickly, that you can then modify and create resources as required, instead of creating the files from scratch.

## POD
- `kubectl run nginx --image=nginx`: create an NGINX Pod
- `kubectl run nginx --image=nginx --dry-run=client -o yaml`: generate POD Manifest YAML file (-o yaml) but don't create it(--dry-run)
- `kubectl run httpd --image=httpd:alpine --port 80 --expose`: create an HTTPD Pod and Service and expose it

## Deployment
- `kubectl create deployment --image=nginx nginx`: create a deployment
- `kubectl create deployment --image=nginx nginx --dry-run -o yaml`: generate Deployment YAML file (-o yaml) byt don't create it(--dry-run)
- `kubectl create deployment nginx --image=nginx --replicas=4`: generate Deployment with a ReplicaSet that has 4 replica Pods
- `kubectl scale deployment nginx --replicas=4`: scale a deployment up/down using the kubectl scale command
- `kubectl create deployment nginx --image=nginx --dry-run=client -o yaml > nginx-deployment.yaml`: save the YAML definition to a file

## Service
Create a Service named redis-service of type ClusterIP by exposing a redis Pod on port 6379:
- `kubectl expose pod redis --port=6379 --name redis-service -o yaml`
Note: This command will automatically use the pod's labels as selectors.
- `kubectl create service clusterip redis --tcp=6379:6379 --dry-run=client -o yaml`
Note: This command will not use the pod's labels as selectors, instead it will assume selectors as app=redis. You cannot pass in selectors as an option, so it does not work very well if you want a different label set. If so, generate a definition file and modify the selectors before creating the service.

Create a Service named nginx of type NodePort to expose pod nginx's port 80 on port 30080 on the nodes:
- `kubectl expose pod nginx --port=80 --name nginx-service --type=NodePort --dry-run=client -o yaml`
Note: This command will automatically use the pod's labels as selectors, but you cannot specify the node port. You have to generate a definition file and then add the node port in manually before creating the service with the pod.
- `kubectl create service nodeport nginx --tcp=80:80 --node-port=30080 --dry-run=client -o yaml`
Note: This command will not use the pod's labels as selectors

Both the above commands have their own challenges. While one cannot accept a selector the other one cannot accept a node port. In general, I'd go with the `kubectl expose` command. If you need to specify a node port, generate a definition file using the same command, and manually input the nodeport before creating the service.

## Namespaces
- `kubectl create ns dev-ns`: create a new Namespace called `dev-ns`

# Editing Existing Pods
In any of the practical quizzes if you are asked to edit an existing POD, please note the following:
- If you are given a pod definition file, edit that file and use it to create a new pod.
- If you are not given a pod definition file, you may extract the definition to a file using the below command:
```kubectl get pod <pod-name> -o yaml > pod-definition.yaml```
Then edit the file to make the necessary changes, delete and re-create the pod. Use the `kubectl edit pod <pod-name>` command to edit pod properties.

Remember, you CANNOT edit specifications of an existing POD other than the below.
- `spec.containers[*].image`
- `spec.initContainers[*].image`
- `spec.activeDeadlineSeconds`
- `spec.tolerations`

For example On a running pod you cannot edit the environment variables, service accounts, resource limits, etc. So you have 2 options:
1. First option:
  - Run the `kubectl edit pod <pod name>` command.  This will open the pod specification in an editor. 
  - Edit the required properties. When you try to save it, you will be denied because you are attempting to edit a field on the pod that is not editable, so a copy of the file with your changes is saved in a temporary location.
  - You can then delete the existing pod by running the command: `kubectl delete pod webapp`
  - Then create a new pod with your changes using the temporary file: `kubectl create -f /tmp/kubectl-edit-ccvrq.yaml`

2. Second option:
- Extract the pod definition in YAML format to a file using the command: `kubectl get pod webapp -o yaml > my-new-pod.yaml`
- Then make the changes to the exported file using an editor. Save the changes: `vi my-new-pod.yaml`
- Then delete the existing pod: `kubectl delete pod webapp`
- Then create a new pod with the edited file: `kubectl create -f my-new-pod.yaml`

# Editing Existing Deployments
With Deployments you can easily edit any field/property of the POD template. Since the pod template is a child of the deployment specification,  with every change the deployment will automatically delete and create a new pod with the new changes. So if you are asked to edit a property of a POD part of a deployment you may do that simply by running the command:
```kubectl edit deployment my-deployment```

# Rolling Updates, Rollbacks and Deployments
Here are some handy examples for updating a Kubernetes Deployment:

- Creating a deployment, checking the rollout status and history:
In the example below, we will first create a simple deployment and inspect the rollout status and the rollout history:
```bash
$ kubectl create deployment nginx --image=nginx:1.16
deployment.apps/nginx created

$ kubectl rollout status deployment nginx
Waiting for deployment "nginx" rollout to finish: 0 of 1 updated replicas are available...
deployment "nginx" successfully rolled out

$ kubectl rollout history deployment nginx
deployment.extensions/nginx
REVISION CHANGE-CAUSE
1        <none>
```

- Using the --revision flag:
Here the revision 1 is the first version where the deployment was created.
You can check the status of each revision individually by using the --revision flag:
```bash
$ kubectl rollout history deployment nginx --revision=1
deployment.extensions/nginx with revision #1
Pod Template:
  Labels:
    app=nginx
    pod-template-hash=6454457cdb
  Containers:
    nginx:
      Image:       nginx:1.16
      Port:        <none>
      Host Port:   <none>
      Environment: <none>
      Mounts:      <none>
  Volumes: <none>
```

- Using the --record flag:
You would have noticed that the "change-cause" field is empty in the rollout history output. We can use the --record flag to save the command used to create/update a deployment against the revision number.
```bash
$ kubectl set image deployment nginx nginx=nginx:1.17 --record
deployment.extensions/nginx image updated
 
$ kubectl rollout history deployment nginx
deployment.extensions/nginx
REVISION CHANGE-CAUSE
1        <none>
2        kubectl set image deployment nginx nginx=nginx:1.17 --record=true
```
You can now see that the change-cause is recorded for the revision 2 of this deployment.
Let's make some more changes. In the example below, we are editing the deployment and changing the image from nginx:1.17 to nginx:latest while making use of the --record flag.
```bash
$ kubectl edit deployments. nginx --record
deployment.extensions/nginx edited
 
$ kubectl rollout history deployment nginx
REVISION CHANGE-CAUSE
1        <none>
2        kubectl set image deployment nginx nginx=nginx:1.17 --record=true
3        kubectl edit deployments. nginx --record=true
 
$ kubectl rollout history deployment nginx --revision=3
deployment.extensions/nginx with revision #3
Pod Template:
  Labels:
    app=nginx
    pod-template-hash=df6487dc
  Annotations: 
    kubernetes.io/change-cause: kubectl edit deployments. nginx --record=true
  Containers:
    nginx:
      Image:       nginx:latest
      Port:        <none>
      Host Port:   <none>
      Environment: <none>
      Mounts:      <none>
  Volumes:   <none>
```

- Undoing a change:
Let's now rollback to the previous revision of the deployment with the image = nginx:1.17:
```bash
$ kubectl rollout undo deployment nginx
deployment.extensions/nginx rolled back
 
$ kubectl rollout history deployment nginx
deployment.extensions/nginxREVISION CHANGE-CAUSE
1     <none>
3     kubectl edit deployments. nginx --record=true
4     kubectl set image deployment nginx nginx=nginx:1.17 --record=true
 
$ kubectl rollout history deployment nginx --revision=4
deployment.extensions/nginx with revision #4
Pod Template:
  Labels:
    app=nginx
    pod-template-hash=b99b98f9
  Annotations:
    kubernetes.io/change-cause: kubectl set image deployment nginx nginx=nginx:1.17 --record=true
  Containers:
    nginx:
      Image:       nginx:1.17
      Port:        <none>
      Host Port:   <none>
      Environment: <none>
      Mounts:   <none>
  Volumes:   <none>
 
$ kubectl describe deployments. nginx | grep -i image:
  Image:    nginx:1.17
```

# Secrets
Secrets encode data in base64 format. Anyone with the base64 encoded secret can easily decode it, so they are not very safe.

The concept of safety of the Secrets is a bit confusing in Kubernetes. The kubernetes documentation page and a lot of blogs out there refer to secrets as a "safer option" to store sensitive data. They are safer than storing in plain text as they reduce the risk of accidentally exposing passwords and other sensitive data. 

That said, secrets are not encrypted, so they are not safer in that sense. However, some best practices around using secrets make it safer. Some best practices include:
- Not checking-in secret object definition files to source code repositories.
- [Enabling Encryption at Rest](https://kubernetes.io/docs/tasks/administer-cluster/encrypt-data/) for Secrets so they are stored encrypted in ETCD. 

The way in that kubernetes handles secrets also helps:
- A secret is only sent to a node if a pod on that node requires it.
- Kubelet stores the secret into a tmpfs so that the secret is not written to disk storage.
- Once the Pod that depends on the secret is deleted, kubelet will delete its local copy of the secret data as well.

More about the protections and risks of using secrets in [this page](https://kubernetes.io/docs/concepts/configuration/secret/#risks). There are other better ways of handling sensitive data like passwords in Kubernetes, such as using tools like Helm Secrets or HashiCorp Vault.

# Reference:
https://kubernetes.io/docs/reference/kubectl/overview/
https://kubernetes.io/docs/reference/kubectl/conventions/
https://kubernetes.io/docs/reference/kubectl/cheatsheet/