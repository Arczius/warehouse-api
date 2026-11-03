# Warehouse API


## Dependencies
- [Docker](https://www.docker.com/get-started/)
- A Editor of your choice

## Getting set up
1. Open the project in your preferred editor
2. Copy the ```.env.example``` file to a own special ```.env``` file
3. Open `.env` and set your own values
4. Build and start everything:
    ```bash
    docker compose up -d --build
    ```

(Use the ports from your `.env` if you changed them.)
## Connecting to the API
the API will run by default on port 5219, so you can connect to it via ```http://localhost:${API_PORT}```

there also is a swagger ui running in the development environment, that's located at ```http://localhost:${API_PORT}/swagger```

## Stopping the containers

to stop the container you can run the following command:
```bash
# to keep the volume saved:
docker compose down

# to also delete the volume
docker compose down -v
```