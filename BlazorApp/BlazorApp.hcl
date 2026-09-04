job "blazorapp" {
  datacenters = ["dc1"]
  type = "service"

  # Set the environment here per deployment
  # Options: Local, Development, Deployment, Production
  variable {
    key   = "env"
    value = "Local"
  }

  group "blazor" {
    count = 1

    task "blazorapp" {
      driver = "exec"

      config {
        command = "/bin/blazorapp"
      }

      #
      # IMPORTANT:
      # This template writes environment.json into the WASM wwwroot folder
      # INSIDE THE ALLOCATION.
      #
      template {
        data = <<EOF
{
    "Environment": "{{ env }}"
}
                 EOF

        destination = "local/wwwroot/environment.json"
        change_mode = "restart"
      }

      #
      # Your Blazor WASM artifact (zip or folder)
      #
      artifact {
        source      = "local/blazorapp.zip"
        destination = "local/"
      }

      env {
        ASPNETCORE_URLS = "http://0.0.0.0:8080"
      }

      resources {
        cpu    = 200
        memory = 256
      }

      service {
        name = "blazorapp"
        port = "http"
      }

      network {
        port "http" {
          to = 8080
        }
      }
    }
  }
}
