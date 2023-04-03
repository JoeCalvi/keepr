<template>
    <div class="KeepCard">
        <img class="img-fluid keep selectable" :src="keep?.img" :alt="keep?.img">
        <div class="keep-info d-flex justify-content-between align-items-center px-2">
            <span>
                {{ keep?.name }}
            </span>
            <img class="creator-picture rounded-circle" :src="keep?.creator.picture" :alt="keep?.creator.picture">
        </div>
    </div>
</template>


<script>
import { Keep } from '../models/Keep.js';

export default {
    props: { keep: { type: Keep, required: true } },
    setup() {
        return {}
    }
}
</script>


<style lang="scss" scoped>
.keep {
    border-radius: 6.95px;
    filter: drop-shadow(0px 5.55897px 5.55897px rgba(0, 0, 0, 0.25));
}

.keep-info {
    font-family: 'Marko One';
    font-style: normal;
    font-weight: 400;
    font-size: 24px;
    line-height: 32px;
    color: #FFFFFF;
    text-shadow: 1px 1px 2px #2D2D2D;
    transform: translateY(-48px);
}

.creator-picture {
    height: 40px;
    width: 40px;
    filter: drop-shadow(0px 4.79889px 4.79889px rgba(0, 0, 0, 0.25));
}

img:hover {
    box-shadow: 5px 5px 10px rgba(0, 0, 0, 0.25);
}
</style>