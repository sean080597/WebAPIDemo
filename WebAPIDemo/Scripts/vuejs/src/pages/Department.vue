<template>
    <v-container grid-list-md>
        <v-layout row wrap>
            <v-flex xs8>
                <SingleDepartment
                v-for="depart in departments"
                :key="depart.DEPARTMENT_ID"
                :data=depart
                ></SingleDepartment>
            </v-flex>
            sidebar
        </v-layout>
    </v-container>
</template>

<script>
import SingleDepartment from '../components/department/SingleDepartment'

export default {
    components: {SingleDepartment},
    data() {
        return {
            departments: {}
        }
    },
    created() {
        axios.get('/api/department')
        .then(({data}) => (this.departments = data))
        .catch(error => console.log(error.response.data))
    },
}
</script>

<style scoped>

</style>
