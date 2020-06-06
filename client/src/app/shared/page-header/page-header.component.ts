import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-page-header',
  templateUrl: './page-header.component.html',
  styleUrls: ['./page-header.component.scss']
})
export class PageHeaderComponent implements OnInit {
@Input() totalCount: number;
@Input() pageSize: number;
@Input() pageNumber: number;
  constructor() { }

  ngOnInit(): void {
  }

}
