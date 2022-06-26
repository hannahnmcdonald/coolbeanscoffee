<template>
  <div class="side-menu-container">
    <router-link to="/">
      <img id="imgLogo" alt="Cool Beans Logo" src="../assets/logo.png" />
    </router-link>
    <h1>Management Portal</h1>
    <CoolBeansButton
      id="menuInventory"
      is-full-width
      @button:click="goToRoute('/inventory')"
    >
      Inventory
    </CoolBeansButton>
    <CoolBeansButton
      id="menuCustomers"
      is-full-width
      @button:click="goToRoute('/customers')"
    >
      Manage Customers
    </CoolBeansButton>
    <CoolBeansButton
      id="menuInvoice"
      is-full-width
      @button:click="goToRoute('/invoice/new')"
    >
      New Invoice
    </CoolBeansButton>
    <CoolBeansButton
      id="menuOrders"
      is-full-width
      @button:click="goToRoute('/orders')"
    >
      Orders
    </CoolBeansButton>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import CoolBeansButton from "../components/CoolBeansButton.vue";
@Component({
  name: "SideMenu",
  components: { CoolBeansButton },
})
export default class SideMenu extends Vue {
  async goToRoute(route: string) {
    await this.$router.push(route);
  }
}
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";
.side-menu-container {
  background-color: #fdf7f2;
  height: 100vh;
  width: $menu-width;
  display: flex;
  flex-direction: column;
  padding: 0.8rem;
  box-sizing: border-box;
  font-family: 'Raleway', sans-serif;
}
#imgLogo {
  width: 100%;
}
h1 {
  font-size: 1.2rem;
  font-family: 'Raleway', sans-serif;
  margin: 1rem 0;
}
</style>