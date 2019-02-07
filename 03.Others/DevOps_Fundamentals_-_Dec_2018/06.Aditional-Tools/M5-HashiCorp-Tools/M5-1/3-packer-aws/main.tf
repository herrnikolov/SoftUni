provider "aws" {
  access_key = "AKIAJ7ZKFT6HC5XOIYBQ"
  secret_key = "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"
  region     = "eu-central-1"
}

resource "aws_instance" "M5-1-3" {
  ami           = "ami-06863a26f4a103e6c"
  instance_type = "t2.micro"
  key_name      = "terraform-key"
}

output "Public IP" {
  value = "${aws_instance.M5-1-3.public_ip}"
}

output "Public DNS" {
  value = "${aws_instance.M5-1-3.public_dns}"
}
