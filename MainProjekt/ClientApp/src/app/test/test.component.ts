import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

export class Message {
  content: string;
  author: string;
}

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  backendResponse: string;

  constructor(private http: HttpClient) { }

  sendRequestToBackend() {
    var message = new Message();
    message.content = "Jakas wiadomosc";
    message.author = "Patryk Mikulski";
    

   /* this.http.post("https://localhost:44349/" + "kurs" + "/sendMessage", message).subscribe(response => {
      this.backendResponse = (response as any).content
    },
      error => {
        this.backendResponse = error;
      });*/

    this.http.delete("https://localhost:44349/" + "kurs" + "/deleteMessage").subscribe(response => {
      this.backendResponse = (response as any).content
    },
      error => {
        this.backendResponse = error;
      });
  }

  ngOnInit() {
  }

}
