import { Component } from '@angular/core';
import { DataService } from '../data.svc';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  constructor(public svc: DataService, public toastr: ToastrService) {
    this.location = {
      lat : '',
      lng : ''
    }
  }

  search: string;
  searchOptions: string[] = [];
  location: any;
  keypressTimeout: any;

  keyPress() {
    if (this.keypressTimeout)
      clearTimeout(this.keypressTimeout);

    this.keypressTimeout = setTimeout(() => {
      this.searchAddress();
    }, 800);
  }

  searchAddress() {
    this.svc.getAddressAutocompleate(this.search).subscribe(resp => {      
      this.searchOptions = [];
      if (resp && resp.error_message) {
        this.toastr.error(resp.error_message);
        return;
      }
      if (resp && resp.predictions) {
        resp.predictions.forEach(el => {
          this.searchOptions.push(el.description);
        })
      }
    });
  }

  getCoordinates() {
    this.svc.getCoordinates(this.search).subscribe(resp => {
      debugger
      if (resp && resp.error_message) {
        this.toastr.error(resp.error_message);
        return;
      }
      if (resp && resp.results && resp.results.length > 0) {
        this.location = resp.results.geometry.location;
      }
      else {
        this.location.lat = '';
        this.location.lng = '';
      }
    });

  }
}
