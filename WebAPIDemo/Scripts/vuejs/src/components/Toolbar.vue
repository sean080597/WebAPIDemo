<template>
  <v-toolbar>
    <!-- <v-toolbar-side-icon></v-toolbar-side-icon> -->
    <v-toolbar-title><router-link class="btn_no_effect" to="/">AppName</router-link></v-toolbar-title>
    <v-spacer></v-spacer>
    <v-toolbar-items class="hidden-sm-and-down">
      <v-btn flat to="/department">Departments</v-btn>
      <v-btn flat to="/employee">Employees</v-btn>
    </v-toolbar-items>
  </v-toolbar>
</template>

<script>
export default {
    
}
</script>

<style scoped>
.btn_no_effect{
  text-decoration: none;
  color: rgba(0,0,0,0.87);
}
</style>
