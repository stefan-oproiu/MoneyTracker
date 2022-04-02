import { Component, OnInit } from '@angular/core';
import { ME_PATH } from '@models';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.scss'],
})
export class ShellComponent implements OnInit {
  readonly ME_PATH = ME_PATH;

  constructor(public authService: AuthService) {}

  ngOnInit(): void {}
}
