import { Inject,Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { ExpenseRecord } from '../models/ExpenseRecord';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class ExpenseRecordService {
    private baseUrl: string;
    private http: HttpClient;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl:string){
        this.baseUrl = `${baseUrl}expenseRecord`;;
        this.http = http;
    }

    getAll(): Observable<ExpenseRecord[]> {
        const api:string = `${this.baseUrl}/all`;
        return this.http.get<ExpenseRecord[]>(api);
    }

    createOne(body: ExpenseRecord): Observable<ExpenseRecord> {
        return this.http.post<ExpenseRecord>(this.baseUrl, body);
    }

    deleteOne(id: string): Observable<any> {
        const api:string = `${this.baseUrl}/${id}`;
        return this.http.delete<any>(api)
    }
}
