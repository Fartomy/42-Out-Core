terraform {
  required_providers {
    vagrant = {
      source  = "bmatcuk/vagrant"
      version = "~> 4.0.0"
    }
  }
}

resource "vagrant_vm" "my_vagrant_vm" {
  vagrantfile_dir = "."
  get_ports = true
}
