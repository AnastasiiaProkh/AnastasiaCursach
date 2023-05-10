import http from "../http-common";
import { TRegularCustomer, TTicketType } from "../types";

class regularCustomerService {
  getAll() {
    return http.get<Array<TRegularCustomer>>("/RegularCustomer");
  }

  create(data: TRegularCustomer) {
    return http.post<Array<TRegularCustomer>>("/RegularCustomer", data);
  }
  delete(id: number) {
    return http.delete<Array<TRegularCustomer>>(`/RegularCustomer/${id}`);
  }
  update(data: TRegularCustomer) {
    return http.put<Array<TRegularCustomer>>("/RegularCustomer", data);
  }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default new regularCustomerService();
