import { Component, OnInit } from '@angular/core';
import { ValuesService } from '../../services/values.service';

@Component({
  selector: 'app-news-list',
  templateUrl: './news-list.component.html',
  styleUrls: ['./news-list.component.css']
})
export class NewsListComponent implements OnInit {

  private list;
  public searchString: string = "";
  public pageNum: number = 1;
  public pageSize: number = 20;
  constructor(private _valuesService: ValuesService) { }

  ngOnInit() {
    this.getStories();
  }


  public pageDown() {
    if (this.pageNum > 1) {
      this.pageNum--;
    }
    this.getStories();
  }

  public pageUp() {
    this.pageNum++;
    this.getStories();
  }

  public search() {

    this.pageNum = 1;
    this.getStories(this.searchString);
  }

  public getStories(search?: string) {
    this._valuesService.getValues(this.pageSize, this.pageNum, search).subscribe(
      data => {
        this.list = data
      },
      err => {
        console.error('err', err)
      }
    )
  }

}
