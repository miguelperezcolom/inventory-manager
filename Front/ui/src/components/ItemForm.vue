<template>
  <div>
    <input type="text" id="name" v-model="item.name" />
    <select id="type" v-model="item.type">
      <option value="Basic">Basic</option>
      <option value="Box">Box</option>
      <option value="Document">Document</option>
    </select>
    <input type="date" id="expirationDate" v-model="item.expirationDate" />
    <button @click="add">Add</button>
  </div>
</template>

<script lang="ts" setup>
import { Item } from "@/model/Item";
import { InventoryService } from "@/client/InventoryService";
import { defineEmits, reactive } from "vue";

const emit = defineEmits(["itemAdded", "errorThrown"]);

const item = reactive(new Item("", "Basic", ""));

const apiClient = new InventoryService();

const add = () => {
  apiClient
    .add(item)
    .then(() => emit("itemAdded"))
    .catch((reason) => emit("errorThrown", reason.response.data));
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
