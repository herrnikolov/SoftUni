bind_addr = "%CLIENT_ADDRESS%" 

# Increase log verbosity
log_level = "DEBUG"

# Setup data dir
data_dir = "/opt/nomad"

addresses {
    http = "%CLIENT_ADDRESS%"
    rpc = "%CLIENT_ADDRESS%"
}

advertise {
  http = "%CLIENT_ADDRESS%:4646"
  rpc = "%CLIENT_ADDRESS%:4647"
}

# Enable the client
client {
  enabled = true

  network_interface = "%CLIENT_INTERFACE%"
  
  # For demo assume we are talking to server1. For production,
  # this should be like "nomad.service.consul:4647" and a system
  # like Consul used for service discovery.
  servers = ["192.168.50.2:4647"]
}
