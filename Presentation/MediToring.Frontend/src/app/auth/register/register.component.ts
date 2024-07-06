import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  username = '';
  email = '';
  password = '';

  constructor(private authService: AuthService, private router: Router) { }

  register() {
    const data = { username: this.username, email: this.email, password: this.password };
    this.authService.register(data).subscribe(
      response => {
        this.router.navigate(['/login']);
      },
      error => {
        console.error('Registration error', error);
      }
    );
  }
}
