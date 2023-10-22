using Swashbuckle.AspNetCore.Filters;
using TransitTracer.Application.Tracer.Queries;

namespace TransitTracer.API.Examples.TracerController;

public class GetWeekData : IExamplesProvider<Dictionary<string,
    Dictionary<int,
        Dictionary<int,
            Dictionary<int, ICollection<StopData>>>>>>
{
    public Dictionary<string, Dictionary<int, Dictionary<int, Dictionary<int, ICollection<StopData>>>>> GetExamples()
    {
        return new Dictionary<string, Dictionary<int, Dictionary<int, Dictionary<int, ICollection<StopData>>>>>
        {
            {
                "Monday", new Dictionary<int, Dictionary<int, Dictionary<int, ICollection<StopData>>>>
                {
                    {
                        338, new Dictionary<int, Dictionary<int, ICollection<StopData>>>
                        {
                            {
                                1, new Dictionary<int, ICollection<StopData>>
                                {
                                    {
                                        146, new List<StopData>
                                        {
                                            new()
                                            {
                                                In = 13,
                                                Out = 15,
                                                Current = 3
                                            },
                                            new()
                                            {
                                                In = 8,
                                                Out = 5,
                                                Current = 3
                                            }
                                        }
                                    }
                                }
                            },
                            {
                                2, new Dictionary<int, ICollection<StopData>>
                                {
                                    {
                                        146, new List<StopData>
                                        {
                                            new()
                                            {
                                                In = 13,
                                                Out = 15,
                                                Current = 3
                                            },
                                            new()
                                            {
                                                In = 8,
                                                Out = 5,
                                                Current = 3
                                            }
                                        }
                                    }
                                }
                            },
                            {
                                3, new Dictionary<int, ICollection<StopData>>
                                {
                                    {
                                        256, new List<StopData>
                                        {
                                            new()
                                            {
                                                In = 13,
                                                Out = 15,
                                                Current = 3
                                            },
                                            new()
                                            {
                                                In = 8,
                                                Out = 5,
                                                Current = 3
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    {
                        292, new Dictionary<int, Dictionary<int, ICollection<StopData>>>
                        {
                            {
                                1, new Dictionary<int, ICollection<StopData>>
                                {
                                    {
                                        146, new List<StopData>
                                        {
                                            new()
                                            {
                                                In = 13,
                                                Out = 15,
                                                Current = 3
                                            },
                                            new()
                                            {
                                                In = 8,
                                                Out = 5,
                                                Current = 3
                                            }
                                        }
                                    }
                                }
                            },
                            {
                                2, new Dictionary<int, ICollection<StopData>>
                                {
                                    {
                                        256, new List<StopData>
                                        {
                                            new()
                                            {
                                                In = 13,
                                                Out = 15,
                                                Current = 3
                                            },
                                            new()
                                            {
                                                In = 8,
                                                Out = 5,
                                                Current = 3
                                            }
                                        }
                                    }
                                }
                            },
                            {
                                3, new Dictionary<int, ICollection<StopData>>
                                {
                                    {
                                        146, new List<StopData>
                                        {
                                            new()
                                            {
                                                In = 13,
                                                Out = 15,
                                                Current = 3
                                            },
                                            new()
                                            {
                                                In = 8,
                                                Out = 5,
                                                Current = 3
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            },
            {
                "Tuesday", new Dictionary<int, Dictionary<int, Dictionary<int, ICollection<StopData>>>>
                {
                    {
                        338, new Dictionary<int, Dictionary<int, ICollection<StopData>>>
                        {
                            {
                                1, new Dictionary<int, ICollection<StopData>>
                                {
                                    {
                                        1, new List<StopData>
                                        {
                                            new()
                                            {
                                                In = 13,
                                                Out = 15,
                                                Current = 3
                                            },
                                            new()
                                            {
                                                In = 8,
                                                Out = 5,
                                                Current = 3
                                            }
                                        }
                                    }
                                }
                            },
                            {
                                2, new Dictionary<int, ICollection<StopData>>
                                {
                                    {
                                        1, new List<StopData>
                                        {
                                            new()
                                            {
                                                In = 13,
                                                Out = 15,
                                                Current = 3
                                            },
                                            new()
                                            {
                                                In = 8,
                                                Out = 5,
                                                Current = 3
                                            }
                                        }
                                    }
                                }
                            },
                            {
                                3, new Dictionary<int, ICollection<StopData>>
                                {
                                    {
                                        1, new List<StopData>
                                        {
                                            new()
                                            {
                                                In = 13,
                                                Out = 15,
                                                Current = 3
                                            },
                                            new()
                                            {
                                                In = 8,
                                                Out = 5,
                                                Current = 3
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    {
                        292, new Dictionary<int, Dictionary<int, ICollection<StopData>>>
                        {
                            {
                                1, new Dictionary<int, ICollection<StopData>>
                                {
                                    {
                                        1, new List<StopData>
                                        {
                                            new()
                                            {
                                                In = 13,
                                                Out = 15,
                                                Current = 3
                                            },
                                            new()
                                            {
                                                In = 8,
                                                Out = 5,
                                                Current = 3
                                            }
                                        }
                                    }
                                }
                            },
                            {
                                2, new Dictionary<int, ICollection<StopData>>
                                {
                                    {
                                        1, new List<StopData>
                                        {
                                            new()
                                            {
                                                In = 13,
                                                Out = 15,
                                                Current = 3
                                            },
                                            new()
                                            {
                                                In = 8,
                                                Out = 5,
                                                Current = 3
                                            }
                                        }
                                    }
                                }
                            },
                            {
                                3, new Dictionary<int, ICollection<StopData>>
                                {
                                    {
                                        1, new List<StopData>
                                        {
                                            new()
                                            {
                                                In = 13,
                                                Out = 15,
                                                Current = 3
                                            },
                                            new()
                                            {
                                                In = 8,
                                                Out = 5,
                                                Current = 3
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}