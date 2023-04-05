<template>
    <div class="offcanvas offcanvas-top" tabindex="-1" aria-labelledby="offcanvasExampleLabel">
        <div class="offcanvas-header d-flex justify-content-end">
            <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
        </div>
        <div class="offcanvas-body d-flex flex-column justify-content-center">
            <slot></slot>
        </div>
    </div>
</template>


<script>
export default {
    setup() {
        return {}
    }
}
</script>


<style lang="scss" scoped>
.offcanvas {
    height: 50vh;
    background-color: #FEF6F0;
}
</style>