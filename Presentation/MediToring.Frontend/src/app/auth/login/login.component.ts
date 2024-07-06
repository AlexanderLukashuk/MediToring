import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username = '';
  password = '';

  constructor(private authService: AuthService, private router: Router) { }

  login() {
    const data = { username: this.username, password: this.password };
    this.authService.login(data).subscribe(
      response => {
        localStorage.setItem('token', response.token);
        this.router.navigate(['/medication']);
      },
      error => {
        console.error('Login error', error);
      }
    );
  }
}
