import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { Observable, map } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

export const authGuard: CanActivateFn = ():Observable<boolean> => {
  const accountService = inject(AccountService);
  const toastrService = inject(ToastrService); 

  return accountService.currentUser$.pipe(
    map(user => {
      if(user) {
        return true;
      }
      else{
        toastrService.error('Do not bypass athtentication.');
        return false;
      }    
    })
  );
};
