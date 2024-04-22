export interface addressModel {
  Name: string;
  StreetnameAndNumber: string;
  Zip: string;
  City: string;

}


export interface ResponseDto<T> {
  messageToClient: string;
  responseData: T;
}
