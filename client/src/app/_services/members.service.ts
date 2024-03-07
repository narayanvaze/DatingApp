import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Member } from '../_models/member';
import { map, of } from 'rxjs';
import { PaginatedResult } from '../_models/pagination';
import { UserParams } from '../_models/userParams';


@Injectable({
  providedIn: 'root'
})

export class MembersService {
  baseUrl = 'https://localhost:5001/api/';
  members: Member[] = [];

  constructor(private http: HttpClient) { }

  getMembers(userParams: UserParams){
    //if(this.members.length > 0) return of (this.members);
    let params = this.getPaginationHeaders(userParams.pageNumber, userParams.pageSize);

    params = params.append('minAge', userParams.minAge.toString());
    params = params.append('maxAge', userParams.maxAge.toString());
    params = params.append('gender', userParams.gender);
    
    return this.getPaginatedResult<Member[]>(this.baseUrl + 'users', params)  
  }

  getMember(username: string){
    const member = this.members.find(x => x.userName === username);
    if(member !== undefined) return of(member);
    return this.http.get<Member>(this.baseUrl + 'users/'+ username);
  }

  updateMember(member: Member){
    return this.http.put(this.baseUrl + 'users', member).pipe(
      map(() => {
        const index = this.members.indexOf(member);
      })
    );
  }
  private getPaginatedResult<T>(url, params) {
    const paginatedResult: PaginatedResult<T> = new PaginatedResult<T>();
    return this.http.get<T>(url, { observe: 'response', params }).pipe(
      map(response => {
        paginatedResult.result = response.body;
        if (response.headers.get('Pagination') !== null) {
        paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }

        return paginatedResult;
      })
    );
  }

  private getPaginationHeaders(pageNumber: number, pageSize: number){
    let params = new HttpParams(); 
  
    params = params.append('pageNUmber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    return params;
  }
}
