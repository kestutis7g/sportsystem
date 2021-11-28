import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api-service';
import { PaginationModel } from 'src/model/PaginationModel';
import { IParkingHistory } from 'src/model/Parking/History/IParkingHistory';
import { IParkingHistoryFilterOptions } from 'src/model/Parking/History/IParkingHistoryFilterOptions';
import { IParkingHistoryFilters } from 'src/model/Parking/History/IParkingHistoryFilters';
import { IParkingHistoryItem } from 'src/model/Parking/History/IParkingHistoryItem';


@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  ParkingHistory?: IParkingHistory;
  ParkingHistoryList?: IParkingHistoryItem[];

  displayedColumns = ['phone', 'table', 'date', 'comment', 'condition']
  isLoadingResults = true;

  pagination: PaginationModel = new PaginationModel();
  pageNumber?: number;

  historyfilterOptionsList?: IParkingHistoryFilterOptions;
  historyFilters: IParkingHistoryFilters =
    {
      condition: "All",
      tableName: [],
      phoneNumber: "",
      comment: ""
    }


  constructor(private service: ApiService) { }

  ngOnInit(): void {
    this.service.getParkingHistoryFilterOptions()
      .subscribe(
        data => {
          this.historyfilterOptionsList = data;
        },
        error => {
          console.log(error);
        }
      );
    this.refreshParkingHistoryList();
  }

  paginatorEvent(e: any) {
    this.pagination.pageSize = e.pageSize;
    
    this.pagination.skip = e.pageIndex * this.pagination.pageSize;
    this.refreshParkingHistoryList();
  }

  filterChange() {
    this.refreshParkingHistoryList();
  }

  refreshParkingHistoryList(){
    this.refreshParkingHistory(this.pagination.skip, this.pagination.pageSize, this.historyFilters);
  }
  
  refreshParkingHistory(skip: number, pageSize: number, historyFilters: IParkingHistoryFilters){
    this.isLoadingResults = true;
    this.service.getParkingHistory(skip, pageSize, historyFilters)
      .subscribe(
        data => {
          this.isLoadingResults = false;
          this.ParkingHistory = data;

          this.ParkingHistoryList = this.ParkingHistory?.parkingHistoryList;
          this.pagination.totalRowCount = this.ParkingHistory?.totalRowCount;
        },
        error => {
          console.log(error);
        }
      );
  }
  
  clearHistory(){
    if (confirm("Are you sure you want to clear history?")){
      this.isLoadingResults = true;
      this.service.clearParkingHistory()
      .subscribe(
        data => {
          this.isLoadingResults = false;
          this.refreshParkingHistoryList();
        },
        error => {
          console.log(error);
        }
      );
    }
  }
      
}
