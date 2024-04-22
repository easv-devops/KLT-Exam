export interface addressModel {
  name: string;
  streetnameAndNumber: string;
  zip: string;
  city: string;
}


export interface ResponseDto<T> {
  messageToClient: string;
  responseData: T;
}
