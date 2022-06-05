import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Role } from 'src/app/models/role';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
  @Output() cancelEdit = new EventEmitter();
  @Input() userFromlistComponent: any;
  roles: any;
  checker: any[] | undefined;

  constructor(private userService: UserService) {
    this.takeRoles();
  }

  takeRoles() {
    this.userService.getRoles().subscribe(response => {
      this.roles = response;
      this.fillArrayCheckes();
    }, error => {
      console.log(error);
    });
  }

  async ngOnInit(): Promise<void> {
  }

  private fillArrayCheckes() {
    this.checker = [];
    for (var i = 0; i < this.roles!.length; i++) {
      this.checker.push({ name: this.roles[i].id, checked: false });
    }
  }

  editUser() {
    var roles: Role[] = [];
    for (var i = 0; i < this.checker!.length; i++) {
      for (var j = 0; j < this.roles!.length; j++) {
        if (this.checker![i].checked && this.checker![i].name == this.roles[j].id) {
          roles.push(this.roles[j]);
        }
      }
    }
    this.userFromlistComponent.roles = roles;
    this.userService.editUser(this.userFromlistComponent);
    this.cancelEdit.emit(false);
  }

  cancel() {
    this.cancelEdit.emit(false);
  }

  onCheck(event: any, $value: any) {
    if (event.target.checked) {
      for (var i = 0; i < this.roles!.length; i++) {
        if (this.checker![i].name == $value) {
          this.checker![i].checked = !this.checker![i].checked;
        }
      }
    }
  }
}
