import { Component, Input } from '@angular/core';
import { NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';
import { Member } from 'src/app/_models/member';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent {
  
  @Input() member: Member
  
  constructor(){}
  
  ngOnInit(){} 
}