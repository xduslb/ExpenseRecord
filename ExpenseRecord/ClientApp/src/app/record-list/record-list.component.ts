import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ExpenseRecord } from '../models/ExpenseRecord';
import { ExpenseRecordService } from '../services/expenseRecord.service';

@Component({
  selector: 'app-record-list',
  templateUrl: './record-list.component.html',
  styleUrls: ['./record-list.component.css']
})
export class ExpenseRecordListComponent implements OnInit, OnDestroy {
  public displayList: Array<ExpenseRecord> = new Array<ExpenseRecord>;
  public newRecord : ExpenseRecord;

  constructor(private expenseRecordService: ExpenseRecordService) {
    this.newRecord = {} as ExpenseRecord;
  }

  ngOnInit(): void {
    this.loadData();
  }

  ngOnDestroy() {

  }

  reload(): void {
    this.loadData();
  }

  private loadData(): void {
    this.expenseRecordService.getAll().subscribe({
      next: item => {
        this.displayList = item;    
        console.log(this.displayList)
      },
      error: () => {
        console.error('Failed to load item');
      }
    });;
  }

  delete(id:string): void {
    const ok = confirm(`Delete this item?`);
    if (ok) {
      this.expenseRecordService.deleteOne(id).subscribe(() => {
          this.reload();
        });
      }}
  create():void{
    this.expenseRecordService.createOne(this.newRecord).subscribe(()=>{
      this.newRecord = {} as ExpenseRecord;
      this.reload();
    })
  }
}
