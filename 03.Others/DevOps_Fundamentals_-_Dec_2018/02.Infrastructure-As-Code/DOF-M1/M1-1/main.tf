provider "aws" {
  access_key = "AKIAIGOPFHF6K5UPBZVQ"
  secret_key = "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"
  region     = "eu-central-1"
}

resource "aws_instance" "M1-1" {
  ami           = "ami-dd3c0f36"
  instance_type = "t2.micro"
  key_name      = "terraform-key"
}

output "Public IP" {
  value = "${aws_instance.M1-1.public_ip}"
}

output "Public DNS" {
  value = "${aws_instance.M1-1.public_dns}"
}
