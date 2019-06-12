<template>
    <v-container grid-list-md>
        <v-layout row wrap>
            <TitleLink title="Department's list"></TitleLink>
            <!-- SidebarTop show in small screen-->
            <v-flex xs12 hidden-md-and-up>
                <SidebarTOP></SidebarTOP>
            </v-flex>

            <!-- List Departments -->
            <v-flex xs8>
                <SingleDepartment
                v-for="(depart, index) in departments"
                :key="depart.DEPARTMENT_ID"
                v-model="departments[index]"
                >
                </SingleDepartment>
            </v-flex>

            <!-- SideBar show in large screen -->
            <v-flex md4 hidden-sm-and-down>
                <Sidebar cate='Department'></Sidebar>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
import TitleLink from '../components/TitleLink'
import SingleDepartment from '../components/department/SingleDepartment'
import Sidebar from '../components/Sidebar'
import SidebarTOP from '../components/SidebarTOP'

export default {
    components: {SingleDepartment, Sidebar, SidebarTOP, TitleLink},
    data() {
        return {
            departments: {},
            // checkedNames: [],
        }
    },
    created() {
        axios.get('/api/department')
        .then(({data}) => (
            // $.each(data, function (indexInArray, valueOfElement) {
            //     data[indexInArray]['checked'] = false
            // }),
            this.departments = data
        ))
        .catch(error => console.log(error.response.data))
    },
    methods: {
        destroySubmit(){
            this.departments = this.departments.filter(this.filters.notDone)
            axios.delete('/api/department', {id: this.checkedNames})
            .then((res) => {

            })
            .catch()
        }
    },
    computed: {
        addFieldChecked(){
            // $.each(this.departments, function (indexInArray, valueOfElement) {
            //     this.departments[indexInArray]['checked'] = false
            // });
            // return ;
        }
    },
}
</script>

<style scoped>

</style>
