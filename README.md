## Build and run the image

In the root folder, build using:
```docker build -t viajemos:latest -f viajemos/viajemos/Dockerfile .```

Then run using
```docker run --name viajemos -d -p 8080:8080 --add-host=host.docker.internal:host-gateway viajemos:latest```

