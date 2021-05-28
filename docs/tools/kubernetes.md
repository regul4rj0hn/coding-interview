# Kubernetes

## Explain
First and foremost, you don't have to remember any YAML file definition by heart, you can just use the explain command to check for their format. 
E.g. if you wanted to see what a pod definition file looks like with all of its objects you can just run:
```kubectl explain pods --recursive | less```

## Formatting Output with kubectl
The default output format for all kubectl commands is the human-readable plain-text format. But the `-o` flag allows us to output the details in several different formats.
```kubectl [command] [TYPE] [NAME] -o <output_format>```
Here are some of the commonly used formats:
- `-o json`: Output a JSON formatted API object.
- `-o name`: Print only the resource name and nothing else.
- `-o wide`: Output in the plain-text format with any additional information.
- `-o yaml`: Output a YAML formatted API object.

This fact combined with the `--dry-run` option can be helpful to quickly create a definition file. E.g. output with YAML format:
```
master $ kubectl create namespace test-123 --dry-run -o yaml
apiVersion: v1
kind: Namespace
metadata:
  creationTimestamp: null
  name: test-123
spec: {}
status: {}
```

## Editing Existing Pods
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
For example you cannot edit the environment variables, service accounts, resource limits of a running pod. But if you really want to, you have 2 options:
1. Run the `kubectl edit pod <pod name>` command.  This will open the pod specification in an editor. Then edit the required properties. When you try to save it, you will be denied. This is because you are attempting to edit a field on the pod that is not editable, so a copy of the file with your changes is saved in a temporary location as shown above. 
- You can then delete the existing pod by running the command:
```kubectl delete pod webapp```
- Then create a new pod with your changes using the temporary file:
```kubectl create -f /tmp/kubectl-edit-ccvrq.yaml```
2. The second option is to extract the pod definition in YAML format to a file using the command:
```kubectl get pod webapp -o yaml > my-new-pod.yaml```
- Then make the changes to the exported file using an editor. Save the changes:
```vi my-new-pod.yaml```
- Then delete the existing pod:
```kubectl delete pod webapp```
- Then create a new pod with the edited file:
```kubectl create -f my-new-pod.yaml```

## Editing Existing Deployments
With Deployments you can easily edit any field/property of the POD template. Since the pod template is a child of the deployment specification,  with every change the deployment will automatically delete and create a new pod with the new changes. So if you are asked to edit a property of a POD part of a deployment you may do that simply by running the command:
```kubectl edit deployment my-deployment```

## Imperative Commands
While you would mostly be working mostly the declarative way - using definition files, imperative commands can help in getting one time tasks done quickly, as well as generate a definition template easily. This helps save a considerable amount of time during certifications. Before we begin, familiarize with the two options that can come in handy while working with the below commands:
- `--dry-run`: By default as soon as the command is run, the resource will be created. If you simply want to test your command, use the `--dry-run=client` option. This will not create the resource, instead, tell you whether the resource can be created and if your command is right.
- `-o yaml`: This will output the resource definition in YAML format on the screen.
Use the above two in combination to generate a resource definition file quickly, that you can then modify and create resources as required, instead of creating the files from scratch.

### POD
- Create an NGINX Pod
```kubectl run nginx --image=nginx```
- Generate POD Manifest YAML file (-o yaml). Don't create it(--dry-run)
```kubectl run nginx --image=nginx --dry-run=client -o yaml```
- Create an HTTPD Pod and Service and expose it
```kubectl run httpd --image=httpd:alpine --port 80 --expose```

### Deployment
- Create a deployment
```kubectl create deployment --image=nginx nginx```
- Generate Deployment YAML file (-o yaml). Don't create it(--dry-run)
```kubectl create deployment --image=nginx nginx --dry-run -o yaml```
- Generate Deployment with 4 Replicas
```kubectl create deployment nginx --image=nginx --replicas=4```
- You can also scale a deployment using the kubectl scale command.
```kubectl scale deployment nginx --replicas=4```
- Another way to do this is to save the YAML definition to a file.
```kubectl create deployment nginx --image=nginx --dry-run=client -o yaml > nginx-deployment.yaml```

You can then update the YAML file with the replicas or any other field before creating the deployment.

### Service
- Create a Service named redis-service of type ClusterIP to expose pod redis on port 6379
```kubectl expose pod redis --port=6379 --name redis-service --dry-run=client -o yaml```
(This will automatically use the pod's labels as selectors)
```kubectl create service clusterip redis --tcp=6379:6379 --dry-run=client -o yaml```
(This will not use the pods labels as selectors, instead it will assume selectors as app=redis. You cannot pass in selectors as an option. So it does not work very well if your pod has a different label set. So generate the file and modify the selectors before creating the service)
- Create a Service named nginx of type NodePort to expose pod nginx's port 80 on port 30080 on the nodes:
```kubectl expose pod nginx --port=80 --name nginx-service --type=NodePort --dry-run=client -o yaml```
(This will automatically use the pod's labels as selectors, but you cannot specify the node port. You have to generate a definition file and then add the node port in manually before creating the service with the pod.)
```kubectl create service nodeport nginx --tcp=80:80 --node-port=30080 --dry-run=client -o yaml```
(This will not use the pods labels as selectors)

Both the above commands have their own challenges. While one of it cannot accept a selector the other cannot accept a node port. I would recommend going with the `kubectl expose` command. If you need to specify a node port, generate a definition file using the same command and manually input the nodeport before creating the service.

### Namespaces
- Create a new Namespace called `dev`

```kubectl create ns dev-ns```


## About Secrets
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

## Reference:
https://kubernetes.io/docs/reference/kubectl/cheatsheet/
https://kubernetes.io/docs/reference/kubectl/conventions/
https://kubernetes.io/docs/reference/kubectl/overview/