import { Component, Input, OnInit } from '@angular/core';

import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html'
})
export class LayoutComponent implements OnInit {
  moduleId=-1;
  constructor(private route:ActivatedRoute) { 
        this.moduleId = route.snapshot.data['moduleId'];
  }
  ngOnInit(): void {
  }

}
