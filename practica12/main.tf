# google_compute_instance.default:
provider "google"{
    credentials= file("concise-rex-312602-cc72eba970e9.json")
    project="concise-rex-312602"
    region="us-west1"
}

resource "google_compute_instance" "default" {
    can_ip_forward          = false
    
    deletion_protection     = false
    enable_display          = false
    
    
    machine_type            = "f1-micro"
    metadata                = {
        "ssh-keys" = <<-EOT
            200714432lh:---- BEGIN SSH2 PUBLIC KEY ----
            Comment: "200714432lh"
            AAAAB3NzaC1yc2EAAAABJQAAAQEAl6RMmM+ym/n/xDw9oBU4FsXcFnKz0wBWnwQ+
            xp5Hc8/4ccR/R0CF4U3jA/xa8UAAvQNDAgJIKdkdX2yxIkmiC1MWbuUBXCe0mEsm
            Tq8BFIGQ7oeKjaEip+w9T11KB2JvU2WZwTbEFK2qz3EUfVJB+a1IsDqem2VxNyK9
            FU1gmOo69PWkoXB6xIw78puILZ1E/q7+mU561fpdAPr+5li7gEyw7guQ5hiuiR7/
            QmEHOJCEpQMkp3AjW2hdqj4RLw7I9S5f1BRj5N10KDA2mryr/WgH8SGq3A+uQ3fk
            G820367wauT37qH60bAcNQU/y05rFvdXdezR24RB2tvjFNL8PQ==
            ---- END SSH2 PUBLIC KEY ----
        EOT
    }
    
    metadata_startup_script = "sudo apt-get update; sudo apt-get install -yq build-essential python-pip rsync; pip install flask"
    name                    = "practica12"
    project                 = "concise-rex-312602"
    zone                    = "us-west1-a"

    network_interface {
        network="default"
        access_config {
            //leer la ip publica

        }
    }

    boot_disk {
        initialize_params{
            image="debian-cloud/debian-9"
        }
    }
  
}
