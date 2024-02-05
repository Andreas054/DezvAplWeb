import { Component, OnInit } from '@angular/core';
import { ApiserviceService } from '../apiservice.service';


@Component({
  selector: 'app-user',
  standalone: true,
  imports: [],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent implements OnInit {

  constructor(private apiservice: ApiserviceService) { }

  ngOnInit(): void {
    this.apiservice.getAll<any>("Employee/getEmployees").subscribe(data => {
      console.log(data);
    });
  }
}
