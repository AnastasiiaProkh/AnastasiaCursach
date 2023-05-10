import http from "../http-common";
import { TAdvertisingAgencies } from "../types";

class advertisingAgenciesService {
  getAll() {
    return http.get<Array<TAdvertisingAgencies>>("/AdvertasingAgencies");
  }

  create(data: TAdvertisingAgencies) {
    return http.post<Array<TAdvertisingAgencies>>("/AdvertasingAgencies", data);
  }
  delete(id: number) {
    return http.delete<Array<TAdvertisingAgencies>>(
      `/AdvertasingAgencies/${id}`
    );
  }
  update(data: TAdvertisingAgencies) {
    return http.put<Array<TAdvertisingAgencies>>("/AdvertasingAgencies", data);
  }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default new advertisingAgenciesService();
