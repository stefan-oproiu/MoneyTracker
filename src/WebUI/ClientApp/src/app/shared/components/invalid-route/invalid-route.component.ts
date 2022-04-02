import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'mt-invalid-route',
  templateUrl: './invalid-route.component.html',
  styleUrls: ['./invalid-route.component.scss']
})
export class InvalidRouteComponent implements OnInit {
  @Input() icon: string = '';
  @Input() message: string = '';

  constructor() { }

  ngOnInit(): void {
  }

}
