import { Component, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-demo',
  standalone: true,
  imports: [CommonModule, MatCardModule],
  templateUrl: './demo.component.html',
  styleUrl: './demo.component.scss'
})
export class DemoComponent implements OnInit, OnDestroy, OnChanges {
  public title: string = "Demo Component";

  constructor() {
    let div = document.getElementById('titleContainer');
    console.log("Constructor titleContainer value", div);
  }

  ngOnChanges(changes: SimpleChanges): void {

  }

  ngOnDestroy(): void {

  }

  ngOnInit(): void {
    let div = document.getElementById('titleContainer');
    console.log("OnInit titleContainer value", div);
  }
}
