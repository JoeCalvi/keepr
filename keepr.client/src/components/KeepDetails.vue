<template>
    <div class="modal-content modal-keep-details">
        <div class="container-fluid">
            <div class="row d-flex align-items-center">
                <div class="col-md-6 keep-image" :style="`background-image: url(${keep?.img})`"></div>
                <div class="col-md-6 keep-info">
                    <div class="row">
                        <div class="col-md-6">
                            <span>{{ keep?.views }}</span>
                        </div>
                        <div class="col-md-6">
                            <span>{{ keep?.kept }}</span>
                        </div>
                    </div>
                    <div class="row"></div>
                    <div class="row"></div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";
export default {
    setup() {
        return {
            keep: computed(() => AppState.activeKeep)
        }
    }
}
</script>


<style lang="scss" scoped>
.keep-image {
    width: 549px;
    height: 657px;
    border-radius: 21px 0px 0px 21px;
    background-size: cover;
    background-position: center;
}

.keep-info {
    width: 549px;
    height: 657px;
    border-radius: 0px 21px 21px 0px;
    background-color: #FEF6F0;
}

.modal-keep-details {
    border-radius: 21px 21px 21px 21px;
    width: 1100px;
    height: 657px;
}
</style>