import { Injectable } from '@angular/core';

    @Injectable()

    export class ParamsModel {
        private baseUrl: string = "http://localhost:5222/api/";

        constructor() {}

        public getUrl() {
            return this.baseUrl;
        }
    }