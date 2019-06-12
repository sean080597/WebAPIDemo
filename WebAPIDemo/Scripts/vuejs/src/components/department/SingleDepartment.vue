<template>
    <v-card class="mb-2">
        <v-card-title primary-title>
            <v-layout row wrap>
                <v-checkbox hide-details class="shrink mr-2"></v-checkbox>
                <v-flex>
                    <router-link :to="'/department/employee/' + model.DEPARTMENT_ID">
                        <h3 class="headline mb-0">
                            {{model.DEPARTMENT_NAME}}
                        </h3>
                    </router-link>
                    <div class="grey--text">{{model.DEPARTMENT_HEAD}}</div>
                </v-flex>
            </v-layout>
        </v-card-title>
    </v-card>
</template>

<script>
export default {
    props: {
        value: {
            type: Object,
            required: true
        }
    },
    computed: {
        model:{
            get() {return this.value},
            set(v) {this.$emit("input", v)}
        }
    },
}
</script>