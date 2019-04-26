using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outbreak
{
    public interface IDamageable
    {
        void TakeDamage(float damage);
    }
}