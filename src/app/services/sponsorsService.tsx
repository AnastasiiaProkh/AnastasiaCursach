import http from "../http-common";
import { TSponsors, TTicketType } from "../types";

class sponsorsService {
  getAll() {
    return http.get<Array<TSponsors>>("/Sponsors");
  }

  create(data: TSponsors) {
    return http.post<Array<TSponsors>>("/Sponsors", data);
  }
  delete(id: number) {
    return http.delete<Array<TSponsors>>(`/Sponsors/${id}`);
  }
  update(data: TSponsors) {
    return http.put<Array<TSponsors>>("/Sponsors", data);
  }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default new sponsorsService();
