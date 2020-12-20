import http from "./http-common";

class DishDataService {
  getAll() {
    return http.get("/dishes");
  }

  get(id) {
    return http.get(`/dishes/${id}`);
  }

  create(data) {
    return http.post("/dishes", data);
  }

  update(id, data) {
    return http.put(`/dishes/${id}`, data);
  }

  delete(id) {
    return http.delete(`/dishes/${id}`);
  }

  deleteAll() {
    return http.delete(`/dishes`);
  }

  findByTitle(title) {
    return http.get(`/dishes?title=${title}`);
  }
}

export default new DishDataService();
