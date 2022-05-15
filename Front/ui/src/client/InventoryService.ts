import { Item } from "@/model/Item";
import http from "@/client/http-common";

export class InventoryService {
  add(item: Item): Promise<any> {
    console.log("add", item);
    return http.post("/items", item);
  }

  remove(item: Item): Promise<any> {
    console.log("remove", item);
    return http.delete("/items", { data: item });
  }

  getAll(): Promise<any> {
    console.log("getAll");
    return http.get("/items");
  }
}
