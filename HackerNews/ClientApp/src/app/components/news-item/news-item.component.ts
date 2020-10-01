import { Component, OnInit, Input } from '@angular/core';
import { ValuesService } from '../../services/values.service';
import { story } from '../../models/story';

@Component({
  selector: 'app-news-item',
  templateUrl: './news-item.component.html',
  styleUrls: ['./news-item.component.css']
})
export class NewsItemComponent implements OnInit {

  @Input() story: story;
  @Input() index; number;

  constructor() { }

  ngOnInit() {
    
  }

}
