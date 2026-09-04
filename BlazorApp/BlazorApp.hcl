task "blazorapp" {
  driver = "exec"

  config {
    command = "/bin/blazorapp"
  }

  template {
    data = <<EOF
{
  "Environment": "{{ env }}"
}
EOF

    destination = "local/wwwroot/environment.json"
    change_mode = "restart"
  }

  # your artifact, env, http, etc...
}
