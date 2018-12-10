# Output useful information
output "public_ip" {
    value = "${join(", ", aws_instance.dof-server.*.public_ip)}"
}