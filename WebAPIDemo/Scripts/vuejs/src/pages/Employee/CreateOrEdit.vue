<template>
    <v-container grid-list-md>
        <v-layout row wrap align-center justify-center>
            <TitleLink title="Employee/Create"></TitleLink>
            <!-- List employees -->
            <v-flex xs8 sm10 md6>
                <v-form @submit.prevent = "createEmployee">
                    <v-text-field
                        label="Employee Name"
                        type="text"
                        v-model="form.empName"
                        v-validate="'required|max:50'"
                        :error-messages="errors.collect('Employee Name')"
                        data-vv-name="Employee Name"
                        required
                    ></v-text-field>
                    <v-text-field
                        label="Age"
                        type="number"
                        v-model="form.empAge"
                        v-validate="'required|numeric|min_value:18|max_value:50'"
                        :error-messages="errors.collect('Employee Age')"
                        data-vv-name="Employee Age"
                        required
                    ></v-text-field>
                    <v-text-field
                        label="Salary"
                        type="number"
                        v-model="form.empSalary"
                        v-validate="'required|numeric'"
                        :error-messages="errors.collect('Employee Salary')"
                        data-vv-name="Employee Salary"
                        required
                    ></v-text-field>
                    <v-autocomplete
                        :items="departments"
                        item-text="DEPARTMENT_NAME"
                        item-value="DEPARTMENT_ID"
                        label="Department Name"
                        v-model="form.empDepartID"
                        v-validate="'required'"
                        :error-messages="errors.collect('Department Name')"
                        data-vv-name="Department Name"
                        required
                    ></v-autocomplete>

                    <v-btn color="primary" type="submit">Create</v-btn>
                </v-form>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
import TitleLink from '../../components/TitleLink'

export default {
    components: {TitleLink},
    $_veeValidate: {
      validator: 'new'
    },
    data() {
        return {
            form: {
                empName: null,
                empAge: null,
                empSalary: null,
                empDepartID: null
            },
            departments: [],
            dictionary: {
                custom: {
                    'Employee Name':{
                        required: () => 'Name can not be empty',
                        max: 'The name field may not be greater than 50 characters'
                    },
                    'Department Name': {
                        required: 'Select field is required'
                    }
                }
            }
        }
    },
    methods: {
        getDepartments(){
            axios.get('/api/department')
            .then(({data}) => this.departments = data)
        },
        createEmployee(){

            this.$validator.validateAll().then((result) => {
                if(result){
                    toast.fire({
                        type: 'info',
                        title: 'Coming soon! =\)\)'
                    });
                }else{
                    this.$Progress.fail();
                }
            })
        }
    },
    created() {
        this.getDepartments()
    },
    mounted () {
        this.$validator.localize('en', this.dictionary)
    },
}
</script>