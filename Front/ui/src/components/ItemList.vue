<template>
  <h3 class="title">Items list</h3>
  <table class="table is-striped is-fullwidth">
    <thead>
      <tr>
        <th>Name</th>
        <th>Type</th>
        <th>Expiration date</th>
        <th>...</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in items" :key="item.name">
        <td>{{ item.name }}</td>
        <td>{{ item.type }}</td>
        <td>{{ item.expirationDate }}</td>
        <td>
          <button class="button is-danger" @click="remove(item)">
            <span>Remove</span>
            <span class="icon is-small">
              <i class="fas fa-times"></i>
            </span>
          </button>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script lang="ts" setup>
import { reactive, defineExpose, defineEmits } from "vue";
import { Item } from "../model/Item";
import { InventoryService } from "@/client/InventoryService";
import ResponseData from "@/types/ResponseData";

const emit = defineEmits(["itemRemoved", "errorThrown"]);

const apiClient = new InventoryService();

const items = reactive([]);

const updateItems = () => {
  apiClient
    .getAll()
    .then((response: ResponseData) => {
      items.length = 0;
      items.push(...(response.data as []));
    })
    .catch((reason) => emit("errorThrown", reason));
};

const remove = (item: Item) => {
  apiClient.remove(item).then(() => emit("itemRemoved"));
};

updateItems();

defineExpose({ updateItems });
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
