<template>
  <v-container grid-list-md>
    <v-layout row wrap justify-center>
      <TitleLink title="Employee's list"></TitleLink>
      <!-- SidebarTop show in small screen-->
      <v-flex xs12 sm10 hidden-md-and-up>
        <SidebarTOP></SidebarTOP>
      </v-flex>

      <!-- List employees -->
      <v-flex xs10 sm8 md6>
        <v-flex v-if="employees.length > 0">
          <SingleEmployee
            v-for="(emp, index) in employees"
            :key="emp.EMPLOYEE_ID"
            v-model="employees[index]"
          ></SingleEmployee>
        </v-flex>
        <v-flex v-else>
          <h1 class="grey--text">No Employee</h1>
        </v-flex>
      </v-flex>

      <!-- SideBar show in large screen -->
      <v-flex md4 hidden-sm-and-down>
        <Sidebar cate="Employee"></Sidebar>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import TitleLink from "../components/TitleLink";
import SingleEmployee from "../components/employee/SingleEmployee";
import Sidebar from "../components/Sidebar";
import SidebarTOP from "../components/SidebarTOP";

export default {
  components: { SingleEmployee, Sidebar, SidebarTOP, TitleLink },
  data() {
    return {
      department_id: this.$route.params.department_id,
      employees: []
    };
  },
  methods: {
    loadEmployees() {
      this.$Progress.start();
      if (this.department_id === "undefined" || this.department_id == null) {
        axios
          .get("/api/employee")
          .then(
            ({ data }) => ((this.employees = data), this.$Progress.finish())
          )
          .catch(error => console.log(error.response.data));
      } else {
        axios
          .get("/api/department/employee/" + this.department_id)
          .then(({ data }) => (this.employees = data))
          .catch(error => console.log(error.response.data));
      }
    }
  },
  created() {
    this.loadEmployees();
  }
};
</script>