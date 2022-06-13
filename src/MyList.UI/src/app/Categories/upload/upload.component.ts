import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ParamsModel } from 'src/app/_models/params.model';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})
export class UploadComponent implements OnInit {

  public message: string | undefined;
  public progress: number | undefined;
  @Output() public onUploadFinished = new EventEmitter();

  constructor(private http: HttpClient, private params: ParamsModel) { }

  ngOnInit(): void {
  }

  public uploadFile = (files: any) => {
    if (files.length === 0)
      return;

    let fileToUpload = <File>files[0];
    
    const formData = new FormData();
    const headers = this.params.createHeader();
    const path = this.params.getUrl();

    formData.append('file', fileToUpload, fileToUpload.name);
    

    this.http.post(path + 'Upload', formData, { headers, reportProgress: true, observe: 'events' })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total!);
        }
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.onUploadFinished.emit(event.body);
        }
      },
      )
  }
}
