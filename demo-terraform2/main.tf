provider "google"{
    credentials= file("concise-rex-312602-cc72eba970e9.json")
    project="concise-rex-312602"
    region="us-west1"
}

resource "random_id" "instance_id"{
    byte_length = 8
}

// crear mi maquina virtual
resource "google_compute_instance" "default" {
    name="demo-terraform2-${random_id.instance_id.hex}"
    machine_type = "f1-micro"
    zone = "us-west1-a"

    boot_disk {
      initialize_params{
          image="debian-cloud/debian-9"
      }
    }

    metadata_startup_script = "sudo apt-get update; sudo apt-get install -yq build-essential python-pip rsync; pip install flask"

    network_interface {
      network="default"

      access_config {
        //leer la ip publica

      }
    }

    metadata = {
      ssh-keys = "200714432lh:${file("~/.ssh/public")}"
    }
}

resource "google_compute_firewall" "default"{
    name = "demo-terraform2-python5000"
    network = "default"
    allow {
        protocol = "tcp"
        ports = ["5000"]

    }
}

output "ip" {
    value= google_compute_instance.default.network_interface.0.access_config.0.nat_ip
}