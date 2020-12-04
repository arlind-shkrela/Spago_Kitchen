import http from "../http-common";

class CousinesDataService {
    getAll() {
      return http.get("/cousines");
    }
  
    get(id) {
      return http.get(`/cousines/${id}`);
    }
  
    create(data) {
        console.log(http);
      return http.post("/cousines", data);
    }
  
    update(id, data) {
      return http.put(`/cousines/${id}`, data); 
    }
  
    delete(id) {
      return http.delete(`/cousines/${id}`);
    }
  
    deleteAll() {
      return http.delete(`/cousines`);
    }
  
    findByTitle(title) {
      return http.get(`/cousines?title=${title}`);
    }
  }
  
  export default new CousinesDataService();