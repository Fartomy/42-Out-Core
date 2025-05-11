TF_DIR	    = ./terraform
ANS_DIR     = ./ansible
USER 	   := $(shell echo $$USER)

.PHONY: up down

up:
	@terraform -chdir=$(TF_DIR) init && terraform -chdir=$(TF_DIR) apply -auto-approve
	@ssh-keygen -f "/home/$(USER)/.ssh/known_hosts" -R "[localhost]:2222"
	@sshpass -p 'vagrant' ssh-copy-id -o StrictHostKeyChecking=no -p 2222 vagrant@localhost
	@ansible-playbook -i $(ANS_DIR)/inventory.ini $(ANS_DIR)/playbook.yml

down:
	@cd $(TF_DIR) && vagrant destroy -f && terraform destroy -auto-approve

stat:
	@cd $(TF_DIR) && vagrant status

all:
	echo $(USER)
